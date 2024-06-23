% Pick an image from the loaded data (e.g., the 9th image)
image = MRI_brain(1:end,1:end,9); 

% Display the image in grayscale
figure;
imagesc(image);
colormap(gray);
set(gca, 'dataaspectratio', [1 1 1]);
title('MRI Brain Image 9th');