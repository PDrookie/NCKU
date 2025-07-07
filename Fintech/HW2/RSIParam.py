import sys
import numpy as np
import pandas as pd

# Calculate Exponential Moving Average (EMA)
def calculateEMA(prices, prevEma, window):
    k = 2 / (window + 1)
    ema = prices[-1] * k + prevEma * (1 - k)
    return ema

# Calculate a more smoothed RSI (Exponential Weighted Moving Average for RSI)
def calculateRSI(prices, window):
    priceDiffs = np.diff(prices[-window:])
    gains = np.where(priceDiffs > 0, priceDiffs, 0)
    losses = np.where(priceDiffs < 0, -priceDiffs, 0)

    avgGain = np.mean(gains)
    avgLoss = np.mean(losses)
    
    if avgLoss == 0:
        return 100  # Return 100 if there are no losses
    rs = avgGain / avgLoss
    rsi = 100 - (100 / (1 + rs))
    return rsi

def myStrategy(pastPriceVec, currentPrice, windowSize, alpha, beta, prevEmaShort=None, prevEmaLong=None, prevSignal=None):
    action = 0  # action=1(buy), -1(sell), 0(hold)
    dataLen = len(pastPriceVec)  # Length of the data vector
    if dataLen < windowSize:  # Not enough data to calculate indicators
        return action, prevEmaShort, prevEmaLong, prevSignal

    # Step 1: Calculate RSI using the more smoothed method
    rsi = calculateRSI(pastPriceVec, windowSize)

    # Step 2: Calculate MACD with EMA
    shortWindow = 12  # Typical short window for MACD
    longWindow = 26   # Typical long window for MACD
    signalWindow = 9  # Signal line window for MACD

    if dataLen < longWindow:  # Not enough data for MACD calculation
        return action, prevEmaShort, prevEmaLong, prevSignal

    if prevEmaShort is None:
        prevEmaShort = np.mean(pastPriceVec[-shortWindow:])  # Initialize with SMA
    emaShort = calculateEMA(pastPriceVec, prevEmaShort, shortWindow)

    if prevEmaLong is None:
        prevEmaLong = np.mean(pastPriceVec[-longWindow:])  # Initialize with SMA
    emaLong = calculateEMA(pastPriceVec, prevEmaLong, longWindow)

    macd = emaShort - emaLong  # MACD line

    if prevSignal is None:
        prevSignal = np.mean([macd for _ in range(signalWindow)])  # Initialize signal line with SMA of MACD
    signalLine = (macd - prevSignal) * (2 / (signalWindow + 1)) + prevSignal

    # Step 3: Determine action based on RSI, MACD, and alpha/beta thresholds
    if rsi < alpha and macd > signalLine:  # Buy signal when RSI is low and MACD is bullish
        action = 1
    elif rsi > beta and macd < signalLine:  # Sell signal when RSI is high and MACD is bearish
        action = -1
    else:
        action = 0  # Otherwise, hold

    return action, emaShort, emaLong, signalLine

# Compute return rate over a given price vector, with 3 modifiable parameters
def computeReturnRate(priceVec, windowSize, alpha, beta):
    capital = 1000  # Initial available capital
    capitalOrig = capital  # Original capital
    dataCount = len(priceVec)  # Day size
    suggestedAction = np.zeros((dataCount, 1))  # Vec of suggested actions
    stockHolding = np.zeros((dataCount, 1))  # Vec of stock holdings
    total = np.zeros((dataCount, 1))  # Vec of total asset
    realAction = np.zeros((dataCount, 1))  # Real action

    # Initialize previous EMA values
    prevEmaShort = None
    prevEmaLong = None
    prevSignal = None

    # Run through each day
    for ic in range(dataCount):
        currentPrice = priceVec[ic]  # Current price
        suggestedAction[ic], prevEmaShort, prevEmaLong, prevSignal = myStrategy(
            priceVec[0:ic], currentPrice, windowSize, alpha, beta, prevEmaShort, prevEmaLong, prevSignal
        )  # Obtain the suggested action
        
        # Get real action by suggested action
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
        elif suggestedAction[ic] == 0:  # No action
            realAction[ic] = 0
        else:
            assert False
        total[ic] = capital + stockHolding[ic] * currentPrice  # Total asset, including stock holding and cash 
    returnRate = (total[-1].item() - capitalOrig) / capitalOrig  # Return rate of this run
    return returnRate

if __name__ == '__main__':
    returnRateBest = -1.00  # Initial best return rate
    df = pd.read_csv(sys.argv[1])  # Read stock file
    adjClose = df["Adj Close"].values  # Get adj close as the price vector
    windowSizeMin = 10
    windowSizeMax = 40  # Range of windowSize to explore
    alphaMin = 20
    alphaMax = 40  # Range of alpha to explore
    betaMin = 80
    betaMax = 100  # Range of beta to explore
    # Start exhaustive search
    for windowSize in range(windowSizeMin, windowSizeMax + 1):  # For-loop for windowSize
        for alpha in range(alphaMin, alphaMax + 1):  # For-loop for alpha
            for beta in range(betaMin, betaMax + 1):  # For-loop for beta
                returnRate = computeReturnRate(adjClose, windowSize, alpha, beta)  # Start the whole run with the given parameters
                if returnRate > returnRateBest:  # Keep the best parameters
                    windowSizeBest = windowSize
                    alphaBest = alpha
                    betaBest = beta
                    returnRateBest = returnRate
    print(f"Best settings: windowSize={windowSizeBest}, alpha={alphaBest}, beta={betaBest} ==> returnRate={returnRateBest:.6f}")

