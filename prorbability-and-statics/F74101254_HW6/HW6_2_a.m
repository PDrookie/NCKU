% Do it by an increment step of 1
x = 0:1:100;
y = 1000:1:2000;
% X, Y in 2D
[X, Y] = meshgrid(x, y);
% Parameters
% distribution 1
mu_x1 = 25;
sigma_x2_1 = 20;
mu_y1 = 1250;
sigma_y2_1 = 200;
% distribution 2
mu_x2 = 75;
sigma_x2 = 30;
mu_y2 = 1750;
sigma_y2 = 300;
rho = 0;

% Case 1 Distribution 1
f1 = BivariateNormalDistribution(X, Y, mu_x1, sigma_x2, mu_y1, sigma_y2, rho);

% Case 1 Distribution 2
f2 = BivariateNormalDistribution(X, Y, mu_x2, sigma_x2, mu_y2, sigma_y2, rho);

% Find decision boundary of Case 1
good_accuracy = 0.005 * max(max(f1, f2));
decision_boundary_case1 = abs(f1 - f2) < good_accuracy;

% Case 2 Distribution 1
f3 = BivariateNormalDistribution(X, Y, mu_x1, sigma_x2_1, mu_y1, sigma_y2_1, rho);

% Case 2 Distribution 2
f4 = BivariateNormalDistribution(X, Y, mu_x2, sigma_x2, mu_y2, sigma_y2, rho);

% Find decision boundary of Case 2
good_accuracy = 0.005 * max(max(f3, f4));
decision_boundary_case2 = abs(f3 - f4) < good_accuracy;

% Plotting Case1
figure;

subplot(3, 1, 1);
imagesc(x, y, f1);
colormap(jet);
colorbar;
axis xy;
title('Distribution 1 [25, 30, 1250, 300, 0]');
xlabel('X');
ylabel('Y');

subplot(3, 1, 2);
imagesc(x, y, f2);
colormap(jet);
colorbar;
axis xy;
title('Distribution 2 [75, 30, 1750, 300, 0]');
xlabel('X');
ylabel('Y');

subplot(3, 1, 3);
imagesc(x, y, decision_boundary_case1);
colormap(gray);
axis xy;
title('Decision Boundary (Case 1)');
xlabel('X');
ylabel('Y');

% Plotting Case2
figure;

subplot(3, 1, 1);
imagesc(x, y, f3);
colormap(jet);
colorbar;
axis xy;
title('Distribution 3 [25, 20, 1250, 200, 0]');
xlabel('X');
ylabel('Y');

subplot(3, 1, 2);
imagesc(x, y, f4);
colormap(jet);
colorbar;
axis xy;
title('Distribution 4 [75, 30, 1750, 300, 0]');
xlabel('X');
ylabel('Y');

subplot(3, 1, 3);
imagesc(x, y, decision_boundary_case2);
colormap(gray);
axis xy;
title('Decision Boundary (Case 2)');
xlabel('X');
ylabel('Y');