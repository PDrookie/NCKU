% Calculate mean and standard deviation for each tissue
white_mean = mean(reshapedArray(mask_white == 1));
white_std = std(reshapedArray(mask_white == 1));

gray_mean = mean(reshapedArray(mask_gray == 1));
gray_std = std(reshapedArray(mask_gray == 1));

CSF_mean = mean(reshapedArray(mask_CSF == 1));
CSF_std = std(reshapedArray(mask_CSF == 1));

% Generate x-values for the range of intensities
x = linspace(0, 1880, 256); % Assuming intensity range of 0-4095 with 256 bins

% Calculate the Gaussian probability density functions (PDFs)
white_pdf = normpdf(x, white_mean, white_std);
gray_pdf = normpdf(x, gray_mean, gray_std);
CSF_pdf = normpdf(x, CSF_mean, CSF_std);

% Plot the Gaussian distributions and the combined distribution
figure;
plot(x, white_pdf, 'b', 'LineWidth', 1.5);
hold on;
plot(x, gray_pdf, 'g', 'LineWidth', 1.5);
plot(x, CSF_pdf, 'r', 'LineWidth', 1.5);
combined_pdf = white_pdf + gray_pdf + CSF_pdf;
plot(x, combined_pdf, '--k', 'LineWidth', 1.5);

xlabel('Pixel Intensity');
ylabel('Probability Density');
title('Approximated Gaussian Distributions of Tissues');
legend('White Matter', 'Gray Matter', 'CSF', 'Combined');

hold off;

figure
combined_pdf = white_pdf + gray_pdf + CSF_pdf;
plot(x, combined_pdf, 'k', 'LineWidth', 1.5);

xlabel('Pixel Intensity');
ylabel('Probability Density');
title('Combined Distributions of Tissues');

