function defects = simulate_defects(defective_rate, num_products)
    % Compute the number of defective products
    num_defects = binornd(num_products, defective_rate); 
    
    % Generate a vector with 1s representing defective products
    defects = zeros(1, num_products); % create a array 1xnum_product full with 0
    defects(randperm(num_products, num_defects)) = 1; % change 0 to 1 in random if the product is defective
end