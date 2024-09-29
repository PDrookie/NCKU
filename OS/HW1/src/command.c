#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include "../include/command.h"

char *read_line(){
    char *buffer = (char *)malloc(BUF_SIZE * sizeof(char));
    if(!buffer){
        perror("Unable to allocate buffer");
        exit(1);
    }

    if(fgets(buffer, BUF_SIZE, stdin)){
        if(buffer[0] == '\n' || buffer[0] == ' ' || buffer[0] == '\t'){
            free(buffer);
            buffer = NULL;
        }
        else{
            if(strncmp(buffer, "replay", 6) == 0){
                char *token = strtok(buffer, " ");
                token = strtok(NULL, " ");
                int index = strtol(token, NULL, 10);
                if(index > MAX_RECORD_NUM || index > history_count){
                    free(buffer);
                    buffer = NULL;
                }
                else{
                    char *tmp = (char *)malloc(BUF_SIZE * sizeof(char));
                    int head = 0;
                    if(history_count > MAX_RECORD_NUM){
                        head += history_count % MAX_RECORD_NUM;
                    }
                    strncpy(tmp, history[(head + index - 1) % MAX_RECORD_NUM], BUF_SIZE);
                    token = strtok(NULL, " ");
                    while(token){
                        strcat(tmp, " ");
                        strcat(tmp, token);
                        token = strtok(NULL, " ");
                    }
                    strncpy(buffer, tmp, BUF_SIZE);
                    free(tmp);
                    buffer[strcspn(buffer, "\n")] = 0;
                    strncpy(history[history_count % MAX_RECORD_NUM], buffer, BUF_SIZE);
                    history_count ++;
                }
            }
            else{
                buffer[strcspn(buffer, "\n")] = 0;
                strncpy(history[history_count % MAX_RECORD_NUM], buffer, BUF_SIZE);
                history_count ++;
            }
        }
    }
    return buffer;
}

struct cmd *split_line(char *line){
    int args_length = 10;
    struct cmd *new_cmd = (struct cmd *)malloc(sizeof(struct cmd));
    new_cmd->head = (struct pipes *)malloc(sizeof(struct pipes));
    new_cmd->head->args = (char **)malloc(args_length * sizeof(char *));
    for(int i = 0; i < args_length; i ++){
        new_cmd->head->args[i] = NULL;
    }
    new_cmd->head->length = 0;
    new_cmd->head->next = NULL;
    new_cmd->background = false;
    new_cmd->in_file = NULL;
    new_cmd->out_file = NULL;

    struct pipes *tmp = new_cmd->head;
    char *token = strtok(line, " ");
    while(token != NULL){
        if(token[0] == '|'){
            struct pipes *new_pipe = (struct pipes *)malloc(sizeof(struct pipes));
            new_pipe->args = (char **)malloc(args_length * sizeof(char *));
            for(int i = 0; i < args_length; i ++){
               new_pipe->args[i] = NULL;
            }
            new_pipe->length = 0;
            new_pipe->next = NULL;
            tmp->next = new_pipe;
            tmp = new_pipe;
        }
        else if(token[0] == '<'){
            token = strtok(NULL, " ");
            new_cmd->in_file = token;
        }
        else if(token[0] == '>'){
            token = strtok(NULL, " ");
            new_cmd->out_file = token;
        }
        else if(token[0] == '&'){
            new_cmd->background = true;
        }
        else{
            tmp->args[tmp->length] = token;
            tmp->length ++;
        }
        token = strtok(NULL, " ");
    }
    
    return new_cmd;    
}
