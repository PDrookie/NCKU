% Define the values of X and f(x)
X = 1:14;
funcX = [4 6 7 8 8 11 7 6 5 3 6 12 10 7];

% Plot the probability distribution
bar(X, funcX/100);
xlabel('X');
ylabel('f(X)');
title('Probability Distribution of X');