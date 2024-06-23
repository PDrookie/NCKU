function p = SumMyPoisson(k, lambda)
% lambda: average number of events
% k: number of events
p = 0;
    for i = 0: k
        p = p + exp(-lambda) * (lambda^i / factorial(i)); % The formula 
    end
end