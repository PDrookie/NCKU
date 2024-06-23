x = input("number of event(x) = ");
p = input("average number of events(lambda) = ");
myPoisson(x, p) %call the function
function p = myPoisson(k, lambda)
% lambda: average number of events
% k: number of events
    p = exp(-lambda) * (lambda^k / factorial(k)); % The formula 
end
