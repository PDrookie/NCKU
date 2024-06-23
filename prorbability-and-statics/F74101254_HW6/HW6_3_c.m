% Initial binary masks
mask_white = zeros(880,640,14);
mask_gray = zeros(880,640,14);
mask_CSF = zeros(880,640,14);

% generate the mask for CSF
for i = 1:14
    for j = 1:880
        for k = 1:640
            if MRI_brain(j, k, i) >= 250 && MRI_brain(j, k, i) <= 420 %range from [250, 420]
                mask_CSF(j, k, i) = 1;
            end
        end
    end
end   

% generate the mask for gray matter
for i = 1:14
    for j = 1:880
        for k = 1:640
            if MRI_brain(j, k, i) >= 600 && MRI_brain(j, k, i) <= 1040 %range from [600, 1040]
                mask_gray(j, k, i) = 1;
            end
        end
    end
end 

%generate the mask white matter
for i = 1:14
    for j = 1:880
        for k = 1:640
            if MRI_brain(j, k, i) >= 1100 && MRI_brain(j, k, i) <= 1300 %range from [1100, 1300]
                mask_white(j, k, i) = 1;
            end
        end
    end
end 

% load the image
image = MRI_brain(1:end,1:end,9); 
% Create all the image
image1 = image .*mask_white(1:end,1:end,9);  
image2 = image .*mask_gray(1:end,1:end,9);  
image3 = image .*mask_CSF(1:end,1:end,9);  

figure;
% original image
subplot(2, 2, 1);
imagesc(image);
colormap(gray);
set(gca, 'dataaspectratio', [1 1 1]);
title('MRI Brain Image 9th');

% white matter
subplot(2, 2, 2);
imagesc(image1);
colormap(gray);
set(gca, 'dataaspectratio', [1 1 1]);
title('white matter Image');

% gray matter
subplot(2, 2, 3);
imagesc(image2);
colormap(gray);
set(gca, 'dataaspectratio', [1 1 1]);
title('gray matter Image');

% CSF
subplot(2, 2, 4);
imagesc(image3);
colormap(gray);
set(gca, 'dataaspectratio', [1 1 1]);
title('CSF Image');