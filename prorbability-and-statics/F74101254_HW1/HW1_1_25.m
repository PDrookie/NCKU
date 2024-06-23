%所有sample數據
sample = [72.2 31.9 26.5 29.1 27.3 8.6 22.3 26.5 20.4 12.8 25.1 19.2 24.1 58.2 68.1 89.2 55.1 9.4 14.5 13.9 20.7 17.9 8.5 55.4 38.1 54.2 21.5 26.2 59.1 43.3] 
%計算sample mean
M = mean(sample)
%計算sample median
m = median(sample)
%繪畫出relative frequency histogram, Class Level是5 - 94, 每一個的range是10 (05-14, 15-24, ...)
histogram(sample, 5:10:100, "Normalization","probability")
%計算 10% trimmed mean 
trim = [31.9 26.5 29.1 27.3 22.3 26.5 20.4 12.8 25.1 19.2 24.1 58.2 55.1 14.5 13.9 20.7 17.9 55.4 38.1 54.2 21.5 26.2 59.1 43.3]
t = mean(trim)