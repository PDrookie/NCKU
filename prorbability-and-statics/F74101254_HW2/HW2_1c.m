% Define the defective rates and product proportions for each machine
defective_rates = [0.02, 0.03, 0.02];
product_proportions = [0.3, 0.45, 0.25];

total_products = 100000; % Total number of products to be produced

num_repetitions = 10; % Number of repetitions

prob_B3_given_A = zeros(1, num_repetitions); % Initialize vector to store estimated P(B3|A)

for i = 1:num_repetitions
    % Simulate defect occurrences for each machine for this repetition
    defects_B1 = simulate_defects(defective_rates(1), round(total_products * product_proportions(1)));
    defects_B2 = simulate_defects(defective_rates(2), round(total_products * product_proportions(2)));
    defects_B3 = simulate_defects(defective_rates(3), round(total_products * product_proportions(3)));
    
    % Compute the total number of defective products for each machine
    total_defects_B1 = sum(defects_B1);
    total_defects_B2 = sum(defects_B2);
    total_defects_B3 = sum(defects_B3);
    
    % Compute the probability of A(the total defective product), B1, B2, and B3
    prob_A = (total_defects_B1 + total_defects_B2 + total_defects_B3) / total_products;
    % Compute the probability of B1(the total defective product produce by B1)
    prob_B1 = (total_defects_B1) / (total_products * product_proportions(1));
    % Compute the probability of B2(the total defective product produce by B2)
    prob_B2 = (total_defects_B2) / (total_products * product_proportions(2));
    % Compute the probability of B3(the total defective product produce by B3)
    prob_B3 = (total_defects_B3) / (total_products * product_proportions(3));
    
    % Compute the probability of B3 given A using Bayes' rule
    prob_B3_given_A(i) = prob_B3 / (prob_B1 + prob_B2 + prob_B3);
end

% Save the estimated P(B3|A) to a .mat file
save('prob_B3_given_A.mat', 'prob_B3_given_A');