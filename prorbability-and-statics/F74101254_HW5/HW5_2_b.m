X = generate_samples(1e4);
histogram(X, 'Normalization', 'probability')
xlabel('X')
ylabel('Relative frequency')
title('Relative frequency plot of X samples')

function X = generate_samples(n)
    x = 1:14;
    f = [4 6 7 8 8 11 7 6 5 3 6 12 10 7] / 100;
    X = randsrc(1, n, [x; f]);
end