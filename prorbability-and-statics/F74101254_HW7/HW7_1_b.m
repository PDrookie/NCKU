% Simulate Irwin-Hall distribution and compare to normal distribution
n_values = [1, 2, 20];  % Values of n to simulate

for i = 1:length(n_values)
    n = n_values(i);
    sample_of_Xn = irwin_hall(n);  % Generate the sample

    % Plotting the histogram
    figure;
    histogram(sample_of_Xn, 100, 'Normalization', 'pdf');  % Relative frequency histogram
    hold on;

    % Overlay a normal distribution with mean and standard deviation of the Irwin-Hall distribution
    mu = n/2;  % Mean of Irwin-Hall distribution
    sigma = sqrt(n/12);  % Standard deviation of Irwin-Hall distribution
    x = linspace(mu - 4*sigma, mu + 4*sigma, 100);
    y = normpdf(x, mu, sigma);
    plot(x, y, 'r', 'LineWidth', 2);

    % Set plot title and labels
    title(['Irwin-Hall Distribution with n = ', num2str(n)]);
    xlabel('Value');
    ylabel('Probability Density');

    % Add legend
    legend('Relative Frequency Histogram', 'Normal Distribution');
end
