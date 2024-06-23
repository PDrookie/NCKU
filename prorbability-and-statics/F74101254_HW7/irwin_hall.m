function sample = irwin_hall(n)
    sample_size = 1e6;
    sample = zeros(sample_size, 1);
    
    for i = 1:n
        uniform_sample = rand(sample_size, 1);
        sample = sample + uniform_sample;
    end
end