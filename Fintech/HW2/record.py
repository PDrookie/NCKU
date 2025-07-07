import sys
import numpy as np
import pandas as pd

# 計算 RSI 的函數
def calculateRSI(pastPriceVec, period=14):
    if len(pastPriceVec) < period:
        return 50  # 若資料不足，則返回中間值 50
    gains = []
    losses = []
    for i in range(1, period):
        change = pastPriceVec[-i] - pastPriceVec[-i-1]
        if change > 0:
            gains.append(change)
        else:
            losses.append(abs(change))
    avg_gain = np.mean(gains) if gains else 0
    avg_loss = np.mean(losses) if losses else 0
    if avg_loss == 0:
        return 100  # 沒有損失情況下 RSI 是 100
    rs = avg_gain / avg_loss
    rsi = 100 - (100 / (1 + rs))
    return rsi

# 修改策略為使用 RSI
def myStrategy(pastPriceVec, currentPrice, rsiBuyThreshold, rsiSellThreshold, rsiPeriod):
    action = 0  # 1=買入，-1=賣出，0=保持不動
    
    # 資料不足以計算 RSI，直接返回保持不動
    if len(pastPriceVec) < rsiPeriod:
        return action
    
    rsi = calculateRSI(pastPriceVec, period=rsiPeriod)
    
    if rsi < rsiBuyThreshold:  # RSI 低於買入門檻，表示超賣
        action = 1
    elif rsi > rsiSellThreshold:  # RSI 高於賣出門檻，表示超買
        action = -1
    
    return action

# 計算回報率的函數
def computeReturnRate(priceVec, rsiBuyThreshold, rsiSellThreshold, rsiPeriod):
    capital = 1000  # Initial available capital
    capitalOrig = capital  # original capital
    dataCount = len(priceVec)  # day size
    suggestedAction = np.zeros(dataCount)  # Vec of suggested actions
    stockHolding = 0.0  # Current stock holdings
    total = np.zeros(dataCount)  # Vec of total asset
    
    # Run through each day
    for ic in range(dataCount):
        currentPrice = priceVec[ic]  # current price
        
        if ic >= rsiPeriod - 1:  # 確保計算在有足夠數據的情況下
            suggestedAction[ic] = myStrategy(priceVec[0:ic + 1], currentPrice, rsiBuyThreshold, rsiSellThreshold, rsiPeriod)

            if suggestedAction[ic] == 1:  # Suggested action is "buy"
                if stockHolding == 0:  # "buy" only if you don't have stock holding
                    stockHolding = capital / currentPrice  # Buy stock using cash
                    capital = 0  # Cash
            elif suggestedAction[ic] == -1:  # Suggested action is "sell"
                if stockHolding > 0:  # "sell" only if you have stock holding
                    capital = stockHolding * currentPrice  # Sell stock to have cash
                    stockHolding = 0  # Stock holding
        
        total[ic] = capital + stockHolding * currentPrice  # Total asset, including stock holding and cash

    returnRate = (total[-1] - capitalOrig) / capitalOrig  # Return rate of this run
    return returnRate

if __name__ == '__main__':
    returnRateBest = -1.00  # Initial best return rate
    df = pd.read_csv(sys.argv[1])  # read stock file
    adjClose = df["Adj Close"].values  # get adj close as the price vector

    rsiBuyMin = 20
    rsiBuyMax = 40  # 買入 RSI 閾值範圍
    rsiSellMin = 60
    rsiSellMax = 80  # 賣出 RSI 閾值範圍
    rsiPeriodMin = 10
    rsiPeriodMax = 20  # RSI 週期範圍

    # 對 RSI 閾值、RSI 週期進行搜尋
    for rsiBuyThreshold in range(rsiBuyMin, rsiBuyMax + 1):
        # print(f"Testing rsiBuyThreshold={rsiBuyThreshold}")
        for rsiSellThreshold in range(rsiSellMin, rsiSellMax + 1):
            # print(f"\tTesting rsiSellThreshold={rsiSellThreshold}")
            for rsiPeriod in range(rsiPeriodMin, rsiPeriodMax + 1):
                returnRate = computeReturnRate(adjClose, rsiBuyThreshold, rsiSellThreshold, rsiPeriod)
                # print(f"\t\tTesting rsiPeriod={rsiPeriod} ==> returnRate={returnRate:.6f}")
                if returnRate > returnRateBest:
                    rsiBuyBest = rsiBuyThreshold
                    rsiSellBest = rsiSellThreshold
                    rsiPeriodBest = rsiPeriod
                    returnRateBest = returnRate

    print("Best settings: RSI Buy Threshold=%d, RSI Sell Threshold=%d, RSI Period=%d ==> Return Rate=%f" % (rsiBuyBest, rsiSellBest, rsiPeriodBest, returnRateBest))
