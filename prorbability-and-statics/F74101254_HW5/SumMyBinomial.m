function b = SumMyBinomial(k, n, p) 
    b = 0;
    for i = 0 : k
        if i <= 0
            b = b + p^i * (1-p)^(n-i); % do the function if k <= 0
        else         
            b = b + nchoosek(n, i) * p^i * (1-p)^(n-i); % do the function
        end
    end    
end