INSERT INTO 員工編號_姓名_電子信箱(員工編號,姓名,電子信箱) VALUES ('F71234567', 'Lewis', 'lewis@csie.ncku.edu.tw')
INSERT INTO 員工編號_姓名_電子信箱(員工編號,姓名,電子信箱) VALUES ('F87654321', 'Eddie', 'eddie@csie.ncku.edu.tw')
INSERT INTO 員工編號_姓名_電子信箱(員工編號,姓名,電子信箱) VALUES ('F74101254', '張暐俊', 'F74101254@gs.ncku.edu.tw')
INSERT INTO 員工編號_薪水(員工編號,薪水) VALUES ('F71234567', '100')
INSERT INTO 員工編號_薪水(員工編號,薪水) VALUES ('F87654321', '99999')
INSERT INTO 員工編號_薪水(員工編號,薪水) VALUES ('F74101254', '65535')
INSERT INTO 電話_員工編號(電話, 員工編號) VALUES ('0912345678', 'F71234567')
INSERT INTO 電話_員工編號(電話, 員工編號) VALUES ('0987654321', 'F87654321')
INSERT INTO 電話_員工編號(電話, 員工編號) VALUES ('0961557957', 'F74101254')
SELECT * FROM 員工編號_姓名_電子信箱
SELECT * FROM 電話_員工編號
SELECT * FROM 員工編號_薪水