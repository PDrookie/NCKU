n = input('Input n number: ');  % Order of the Irwin-Hall distribution
sample = irwin_hall(n);  % Generate the sample

% Calculate mean and variance of the generated sample
mean_value = mean(sample);
variance_value = var(sample);

% outputVector = sample;

disp(['Mean:', num2str(mean_value)]);
disp(['Variance:', num2str(variance_value)]);