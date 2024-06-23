UPDATE 員工編號_姓名_電子信箱 SET 電子信箱 = 'hello@csie.ncku.edu.tw' WHERE 員工編號 = 'F71234567'
UPDATE 員工編號_薪水 SET 薪水 = '100000' WHERE 員工編號 = 'F87654321'
UPDATE 電話_員工編號 SET 電話 = '0977777777' WHERE 員工編號 = 'F71234567'
SELECT 員工編號, 電子信箱 FROM 員工編號_姓名_電子信箱
SELECT 電話, 員工編號 FROM 電話_員工編號
SELECT 員工編號, 薪水 FROM 員工編號_薪水