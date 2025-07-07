#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/wait.h>
#include <fcntl.h>
#include "../include/command.h"
#include "../include/builtin.h"

int execute(struct pipes *pipe){
	for(int i = 0; i < num_builtins(); i ++){
		if(!strcmp(pipe->args[0], builtin_str[i])) 
			return (*builtin_func[i])(pipe->args);
	}

	return execvp(pipe->args[0], pipe->args);
}

int spawn_proc(int in, int out, struct cmd *cmd, struct pipes *p){ 
	pid_t pid;
	int status, fd;
	if((pid = fork()) == 0){
		if(in != 0){
			dup2(in, 0);
			close(in);
		}
		else{
			if(cmd->in_file){
				fd = open(cmd->in_file, O_RDONLY);
				dup2(fd, 0);
				close(fd);
			}
		}

		if(out != 1){
			dup2(out, 1);
			close(out);
		}
		else{
			if(cmd->out_file){
				fd = open(cmd->out_file, O_RDWR | O_CREAT, 0644);
				dup2(fd, 1);
				close(fd);
			}
		}
		if(execute(p) == 1) perror("lsh");
		exit(EXIT_FAILURE);
	}
	else{
		if(cmd->background){
			if(!p->next) printf("[pid]: %d\n", pid);
		}
		else{
			do{
				waitpid(pid, &status, WUNTRACED);
			}while(!WIFEXITED(status) && !WIFSIGNALED(status));
		}
	}
  	return 1;
}

int fork_pipes(struct cmd *cmd){
	int in = 0, fd[2];
	struct pipes *tmp = cmd->head;
	while(tmp->next != NULL){
		pipe(fd);
		spawn_proc(in, fd[1], cmd, tmp);
		close(fd[1]);
		in = fd[0];
		tmp = tmp->next;
	}
	if(in != 0){
		spawn_proc(in, 1, cmd, tmp);
		return 1;
	}
	
	spawn_proc(0, 1, cmd, cmd->head);
	return 1;
}

void show_shell_msg(){
    printf("==================================================\n");
    printf("* Wellcome to my simple shell ~~                 *\n");
    printf("*                                                *\n");
    printf("* Type \"help\" to see built in functions.         *\n");
    printf("*                                                *\n");
    printf("* If you want to do things below:                *\n");
    printf("* + redirection: \">\" or \"<\"                      *\n");
    printf("* + pipe: \"|\"                                    *\n");
    printf("* + background: \"&\"                              *\n");
    printf("* Make sure they are seperated by \"(space)\".     *\n");
    printf("*                                                *\n");
    printf("* Let's have fun !!!                             *\n");
    printf("==================================================\n");
}

void shell(){
	while(1){
		printf(">> $ ");

		char *buffer = read_line();
		if(buffer == NULL) continue;

		struct cmd *cmd = split_line(buffer);

		int status = -1;
		if(!cmd->background && cmd->head->next == NULL){
			int file, in = dup(0), out = dup(1);
			if(cmd->in_file){
				file = open(cmd->in_file, O_RDONLY);
				dup2(file, 0);
				close(file);
			}
			if(cmd->out_file){
				file = open(cmd->out_file, O_RDWR | O_CREAT, 0644);
				dup2(file, 1);
				close(file);
			}
			for(int i = 0; i < num_builtins(); i ++){
				if(!strcmp(cmd->head->args[0], builtin_str[i])) 
					status = (*builtin_func[i])(cmd->head->args); 
			}
			if(cmd->in_file) dup2(in, 0);
			if(cmd->out_file) dup2(in, 1);
			close(in);
			close(out);
		}

		if(status == -1) status = fork_pipes(cmd);

		while(cmd->head){
			struct pipes *tmp = cmd->head;
			cmd->head = cmd->head->next;
			free(tmp->args);
			free(tmp);
		}
		free(cmd);
		free(buffer);

		if(!status) break;
	}
}
