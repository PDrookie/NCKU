% Define parameters of the Binomial distributions
n_values = 10000;
p_values = [0.01, 0.1, 0.2, 0.5];

% Generate plots for each (n, p) condition
for i = 1:length(p_values)
    % Calculate the Poisson parameter lambda using the approximation from Binomial distribution
    lambda = n_values * p_values(i);
    
    % Calculate the Binomial distribution
    k = 0:n_values;
    binom_dist = binopdf(k, n_values, p_values(i));
    
    % Calculate the Poisson distribution
    poisson_dist = poisspdf(k, lambda);
    
    % Plot both distributions on the same figure
    figure();
    bar(k, binom_dist, 'g'); % plot the figure with green 
    hold on;
    bar(k, poisson_dist, 'r'); % plot the figure with red
    xlabel('k');
    ylabel('P(X = k)');
    title(sprintf('Binomial vs Poisson distribution (n = %d, p = %.2f)', n_values, p_values(i)));
    legend('Binomial', 'Poisson');
    hold off;
    
    % Calculate the maximum absolute error between the Binomial and Poisson distributions
    max_error = max(abs(binom_dist - poisson_dist));
    fprintf('For (n, p) = (%d, %.2f), the maximum absolute error is %.4f\n', n_values, p_values(i), max_error);
end