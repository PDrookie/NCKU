x = input("number of successes(x) = ");
n = input("number of trials(n) = ") ;
p = input("probability of success(p) = ");
myBinomial(x, n, p) %call the function
function b = myBinomial(k, n, p) 
    if k <= 0
        b = p^k * (1-p)^(n-k); % do the function
    else 
        b = nchoosek(n, k) * p^k * (1-p)^(n-k); % do the function
    end
end

