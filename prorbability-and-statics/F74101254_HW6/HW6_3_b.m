% Concatenate all image slices into a single 2D array
imageArray = cat(3, MRI_brain);

% Reshape the 3D array into a 2D matrix
reshapedArray = reshape(imageArray, [], size(imageArray, 3));

% Plot the intensity histogram
figure;
histogram(reshapedArray, 'BinLimits', [0 3000], 'NumBins', 256);
xlabel('Pixel Intensity');
ylabel('Frequency');
title('Intensity Histogram of MRI Brain Images');