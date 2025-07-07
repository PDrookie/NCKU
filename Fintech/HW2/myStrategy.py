import numpy as np

# Decision of the current day by the current price, with 3 modifiable parameters
def myStrategy(pastPriceVec, currentPrice):
    import numpy as np
    windowSize = 25
    alpha = 17
    beta = 83
    action = 0  # action=1(buy), -1(sell), 0(hold)
    dataLen = len(pastPriceVec)  # Length of the data vector
    if dataLen < windowSize:  # Not enough data to calculate RSI
        return action

    # Step 1: Calculate price differences
    priceDiffs = np.diff(pastPriceVec[-windowSize:])  # Price changes in the window
    gains = np.where(priceDiffs > 0, priceDiffs, 0)  # Positive gains
    losses = np.where(priceDiffs < 0, -priceDiffs, 0)  # Negative losses

    # Step 2: Calculate average gain and loss
    avgGain = np.mean(gains)
    avgLoss = np.mean(losses)

    # Step 3: Calculate RSI
    if avgLoss == 0:  # To avoid division by zero
        rsi = 100
    else:
        rs = avgGain / avgLoss
        rsi = 100 - (100 / (1 + rs))

    # Step 4: Determine action based on RSI and alpha/beta thresholds
    if rsi < alpha:  # RSI below alpha, indicating oversold ==> buy
        action = 1
    elif rsi > beta:  # RSI above beta, indicating overbought ==> sell
        action = -1

    return action
