% Do it by an increment step of 1
x = 0:1:100;
y = 1000:1:2000;
% X, Y in 2D
[X, Y] = meshgrid(x, y);
% Parameters
mu_x = 50;
sigma_x = 20;
mu_y = 1500;
sigma_y = 200;

% Distribution 1
rho1 = 0;
f1 = BivariateNormalDistribution(X, Y, mu_x, sigma_x, mu_y, sigma_y, rho1);

% Distribution 2
rho2 = 0.3;
f2 = BivariateNormalDistribution(X, Y, mu_x, sigma_x, mu_y, sigma_y, rho2);

% Distribution 3
rho3 = 0.8;
f3 = BivariateNormalDistribution(X, Y, mu_x, sigma_x, mu_y, sigma_y, rho3);

% Distribution 4
rho4 = -0.8;
f4 = BivariateNormalDistribution(X, Y, mu_x, sigma_x, mu_y, sigma_y, rho4);

% Plotting
figure;
axis xy

subplot(2, 2, 1);
imagesc(x, y, f1);
colormap(jet);
colorbar;
title('Distribution 1 [50, 20, 1500, 200, 0]');
xlabel('X');
ylabel('Y');
axis xy;

subplot(2, 2, 2);
imagesc(x, y, f2);
colormap(jet);
colorbar;
title('Distribution 2 [50, 20, 1500, 200, 0.3]');
xlabel('X');
ylabel('Y');
axis xy;

subplot(2, 2, 3);
imagesc(x, y, f3);
colormap(jet);
colorbar;
title('Distribution 3 [50, 20, 1500, 200, 0.8]');
xlabel('X');
ylabel('Y');
axis xy;

subplot(2, 2, 4);
imagesc(x, y, f4);
colormap(jet);
colorbar;
title('Distribution 4 [50, 20, 1500, 200, -0.8]');
xlabel('X');
ylabel('Y');
axis xy;
