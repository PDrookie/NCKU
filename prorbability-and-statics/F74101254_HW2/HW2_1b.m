defective_rate = 0.02; % Defective rate for machine B1
num_products = 10000; % Total number of products to be produced
num_repetitions = 1000; % Number of repetitions

defect_counts = zeros(1, num_repetitions); % Initialize vector to store defect counts

for i = 1 : num_repetitions
    % Simulate defect occurrences for this repetition
    defects = simulate_defects(defective_rate, num_products);
    
    % Compute the number of defective products in this repetition
    defect_count = sum(defects);
    
    % Save the defect count for this repetition
    defect_counts(i) = defect_count;
end

% plot the histogram
histogram(defect_counts, 120:10:300, "Normalization", "probability")

% Save the defect counts to a .mat file
save('defect_counts.mat', 'defect_counts');