import sys
import numpy as np
import pandas as pd

# Compute EMA (Exponential Moving Average)
def computeEMA(data, window_size):
    if len(data) < window_size:
        return np.mean(data)  # fallback to mean if not enough data
    alpha = 2 / (window_size + 1)
    ema = data[0]  # start with the first data point
    for price in data[1:]:
        ema = (price * alpha) + (ema * (1 - alpha))
    return ema

# Compute RSI (Relative Strength Index)
def computeRSI(data, window_size):
    if len(data) < window_size:
        return 50  # Default to 50 if not enough data to compute RSI

    gains = np.zeros(len(data))
    losses = np.zeros(len(data))

    for i in range(1, len(data)):
        change = data[i] - data[i - 1]
        if change > 0:
            gains[i] = change
        else:
            losses[i] = -change

    avg_gain = np.mean(gains[-window_size:])
    avg_loss = np.mean(losses[-window_size:])

    if avg_loss == 0:
        return 100  # Avoid division by zero, if no losses return 100

    rs = avg_gain / avg_loss
    rsi = 100 - (100 / (1 + rs))
    return rsi

# Decision of the current day by the current price, with 3 modifiable parameters
def myStrategy(pastPriceVec, currentPrice, windowSize, alpha, beta, rsiThreshold):
    action = 0  # action=1(buy), -1(sell), 0(hold), with 0 as the default action
    dataLen = len(pastPriceVec)  # Length of the data vector
    if dataLen == 0:
        return action
    
    # Compute EMA
    if dataLen < windowSize:
        ma = np.mean(pastPriceVec)  # If given price vector is smaller than windowSize, compute MA by taking the average
    else:
        ma = computeEMA(pastPriceVec[-windowSize:], windowSize)  # Compute EMA using windowSize
    
    # Compute RSI
    rsi = computeRSI(pastPriceVec, windowSize)
    
    # Determine action
    if (currentPrice - ma) > alpha and rsi < rsiThreshold:  # If price-ma > alpha and RSI < threshold ==> buy
        action = 1
    elif (currentPrice - ma) < -beta and rsi > (100 - rsiThreshold):  # If price-ma < -beta and RSI > (100 - threshold) ==> sell
        action = -1
    return action

# Compute return rate over a given price vector, with 4 modifiable parameters
def computeReturnRate(priceVec, windowSize, alpha, beta, rsiThreshold):
    capital = 1000  # Initial available capital
    capitalOrig = capital  # original capital
    dataCount = len(priceVec)  # day size
    suggestedAction = np.zeros((dataCount, 1))  # Vec of suggested actions
    stockHolding = np.zeros((dataCount, 1))  # Vec of stock holdings
    total = np.zeros((dataCount, 1))  # Vec of total asset
    realAction = np.zeros((dataCount, 1))  # Real action
    
    # Run through each day
    for ic in range(dataCount):
        currentPrice = priceVec[ic]  # current price
        suggestedAction[ic] = myStrategy(priceVec[0:ic], currentPrice, windowSize, alpha, beta, rsiThreshold)  # Obtain the suggested action
        
        # get real action by suggested action
        if ic > 0:
            stockHolding[ic] = stockHolding[ic - 1]  # The stock holding from the previous day
        if suggestedAction[ic] == 1:  # Suggested action is "buy"
            if stockHolding[ic] == 0:  # "buy" only if you don't have stock holding
                stockHolding[ic] = capital / currentPrice  # Buy stock using cash
                capital = 0  # Cash
                realAction[ic] = 1
        elif suggestedAction[ic] == -1:  # Suggested action is "sell"
            if stockHolding[ic] > 0:  # "sell" only if you have stock holding
                capital = stockHolding[ic] * currentPrice  # Sell stock to have cash
                stockHolding[ic] = 0  # Stock holding
                realAction[ic] = -1
        else:
            realAction[ic] = 0  # No action

        total[ic] = capital + stockHolding[ic] * currentPrice  # Total asset, including stock holding and cash
    
    returnRate = (total[-1].item() - capitalOrig) / capitalOrig  # Return rate of this run
    return returnRate

if __name__ == '__main__':
    returnRateBest = -1.00  # Initial best return rate
    df = pd.read_csv(sys.argv[1])  # read stock file
    adjClose = df["Adj Close"].values  # get adj close as the price vector
    windowSizeMin = 11
    windowSizeMax = 20  # Range of windowSize to explore
    alphaMin = -5
    alphaMax = 5  # Range of alpha to explore
    betaMin = -5
    betaMax = 5  # Range of beta to explore
    rsiThresholdMin = 30  # Minimum RSI threshold
    rsiThresholdMax = 70  # Maximum RSI threshold
    
    # Start exhaustive search
    for windowSize in range(windowSizeMin, windowSizeMax + 1):  # For-loop for windowSize
        print("windowSize=%d" % (windowSize))
        for alpha in range(alphaMin, alphaMax + 1):  # For-loop for alpha
            print("\talpha=%d" % (alpha))
            for beta in range(betaMin, betaMax + 1):  # For-loop for beta
                for rsiThreshold in range(rsiThresholdMin, rsiThresholdMax + 1, 10):  # For-loop for RSI threshold
                    print("\t\tbeta=%d, rsiThreshold=%d" % (beta, rsiThreshold), end="")  # No newline
                    returnRate = computeReturnRate(adjClose, windowSize, alpha, beta, rsiThreshold)  # Start the whole run with the given parameters
                    print(" ==> returnRate=%f " % (returnRate))
                    if returnRate > returnRateBest:  # Keep the best parameters
                        windowSizeBest = windowSize
                        alphaBest = alpha
                        betaBest = beta
                        rsiThresholdBest = rsiThreshold
                        returnRateBest = returnRate
    print("Best settings: windowSize=%d, alpha=%d, beta=%d, rsiThreshold=%d ==> returnRate=%f" % (windowSizeBest, alphaBest, betaBest, rsiThresholdBest, returnRateBest))  # Print the best result
