import numpy as np

# A simple greedy approach
def myActionSimple(priceMat, transFeeRate):
    # Explanation of my approach:
	# 1. Technical indicator used: Watch next day price
	# 2. if next day price > today price + transFee ==> buy
    #       * buy the best stock
	#    if next day price < today price + transFee ==> sell
    #       * sell if you are holding stock
    # 3. You should sell before buy to get cash each day
    # default
    cash = 1000
    hold = 0
    # user definition
    nextDay = 1
    dataLen, stockCount = priceMat.shape  # day size & stock count   
    stockHolding = np.zeros((dataLen,stockCount))  # Mat of stock holdings
    actionMat = []  # An k-by-4 action matrix which holds k transaction records.
    
    for day in range( 0, dataLen-nextDay ) :
        dayPrices = priceMat[day]  # Today price of each stock
        nextDayPrices = priceMat[ day + nextDay ]  # Next day price of each stock
        
        if day > 0:
            stockHolding[day] = stockHolding[day-1]  # The stock holding from the previous action day
        
        buyStock = -1  # which stock should buy. No action when is -1
        buyPrice = 0  # use how much cash to buy
        sellStock = []  # which stock should sell. No action when is null
        sellPrice = []  # get how much cash from sell
        bestPriceDiff = 0  # difference in today price & next day price of "buy" stock
        stockCurrentPrice = 0  # The current price of "buy" stock
        
        # Check next day price to "sell"
        for stock in range(stockCount) :
            todayPrice = dayPrices[stock]  # Today price
            nextDayPrice = nextDayPrices[stock]  # Next day price
            holding = stockHolding[day][stock]  # how much stock you are holding
            
            if holding > 0 :  # "sell" only when you have stock holding
                if nextDayPrice < todayPrice*(1+transFeeRate) :  # next day price < today price, should "sell"
                    sellStock.append(stock)
                    # "Sell"
                    sellPrice.append(holding * todayPrice)
                    cash = holding * todayPrice*(1-transFeeRate) # Sell stock to have cash
                    stockHolding[day][sellStock] = 0
        
        # Check next day price to "buy"
        if cash > 0 :  # "buy" only when you have cash
            for stock in range(stockCount) :
                todayPrice = dayPrices[stock]  # Today price
                nextDayPrice = nextDayPrices[stock]  # Next day price
                
                if nextDayPrice > todayPrice*(1+transFeeRate) :  # next day price > today price, should "buy"
                    diff = nextDayPrice - todayPrice*(1+transFeeRate)
                    if diff > bestPriceDiff :  # this stock is better
                        bestPriceDiff = diff
                        buyStock = stock
                        stockCurrentPrice = todayPrice
            # "Buy" the best stock
            if buyStock >= 0 :
                buyPrice = cash
                stockHolding[day][buyStock] = cash*(1-transFeeRate) / stockCurrentPrice # Buy stock using cash
                cash = 0
                
        # Save your action this day
        if buyStock >= 0 or len(sellStock) > 0 :
            action = []
            if len(sellStock) > 0 :
                for i in range( len(sellStock) ) :
                    action = [day, sellStock[i], -1, sellPrice[i]]
                    actionMat.append( action )
            if buyStock >= 0 :
                action = [day, -1, buyStock, buyPrice]
                actionMat.append( action )
    return actionMat

# A DP-based approach to obtain the optimal return
def myAction01(priceMat, transFeeRate):
    days, n_stocks = priceMat.shape
    cash_init = 1000.0
    use_cash = -1  # 用 -1 表示現金

    # 初始化動態規劃表和交易記錄
    dp_record = np.zeros((days, n_stocks + 1), dtype=float)  # [stock0, stock1, ..., cash]
    trans_record = np.full((days, n_stocks + 1), -1, dtype=int)  # 記錄每個狀態的來源

    # 第0天初始化
    dp_record[0, :-1] = cash_init / priceMat[0, :] * (1 - transFeeRate)  # 用現金買入每種股票
    dp_record[0, -1] = cash_init  # 持有現金
    trans_record[0, :-1] = use_cash  # 股票是從現金買入的
    trans_record[0, -1] = use_cash  # 現金來源於初始現金

    # 動態規劃主循環
    for i in range(1, days):
        # 更新現金狀態
        max_cash = dp_record[i - 1, -1]  # 繼續持有現金
        trans_cash = -1
        for s in range(n_stocks):
            # 賣出股票 s 獲得現金
            cash_from_sell = dp_record[i - 1, s] * priceMat[i, s] * (1 - transFeeRate)
            if cash_from_sell > max_cash:
                max_cash = cash_from_sell
                trans_cash = s  # 現金來自於賣出股票 s
        dp_record[i, -1] = max_cash
        trans_record[i, -1] = trans_cash

        # 更新每種股票的狀態
        for k in range(n_stocks):
            # 繼續持有股票 k
            max_stock = dp_record[i - 1, k]
            trans_stock = k
            # 用現金買入股票 k
            units_from_cash = dp_record[i - 1, -1] / priceMat[i, k] * (1 - transFeeRate)
            if units_from_cash > max_stock:
                max_stock = units_from_cash
                trans_stock = -1  # 從現金買入
            # 從其他股票交換到股票 k
            for s in range(n_stocks):
                if s != k:
                    # 賣出股票 s，買入股票 k
                    cash_from_s = dp_record[i - 1, s] * priceMat[i, s] * (1 - transFeeRate)
                    units_k = cash_from_s / priceMat[i, k] * (1 - transFeeRate)
                    if units_k > max_stock:
                        max_stock = units_k
                        trans_stock = s
            dp_record[i, k] = max_stock
            trans_record[i, k] = trans_stock

    # 回溯構建 actionMat
    actionMat = []
    # 找到最後一天的最佳狀態
    final_state = -1  # 默認為持有現金
    max_wealth = dp_record[-1, -1]
    for k in range(n_stocks):
        # 計算持有股票 k 的總資產
        wealth = dp_record[-1, k] * priceMat[-1, k] * (1 - transFeeRate)
        if wealth > max_wealth:
            max_wealth = wealth
            final_state = k

    # 從最後一天開始回溯
    state = final_state
    i = days - 1
    while i >= 0:
        prev_state = trans_record[i, state]
        if state == -1:
            # 持有現金
            if prev_state != -1:
                # 賣出股票 prev_state 獲得現金
                amount = dp_record[i - 1, prev_state] * priceMat[i, prev_state]
                actionMat.append([i, prev_state, -1, amount])
        else:
            # 持有股票 state
            if prev_state == -1:
                # 從現金買入股票 state
                amount = dp_record[i, state] * priceMat[i, state] / (1 - transFeeRate)
                actionMat.append([i, -1, state, amount])
            elif prev_state != state:
                # 從股票 prev_state 交換到股票 state
                amount = dp_record[i - 1, prev_state] * priceMat[i, prev_state]
                actionMat.append([i, prev_state, state, amount])
            # 否則，繼續持有同一股票，無需動作
        state = prev_state
        i -= 1

    actionMat.reverse()  # 反轉動作序列，按照時間順序排列
    return actionMat

# An approach that allow non-consecutive K days to hold all cash without any stocks
def myAction02(priceMat, transFeeRate, K):
    days, n_stocks = priceMat.shape
    cash_init = 1000.0
    use_cash = 0  # 用 0 表示持有現金，股票編號從 1 開始

    # 初始化 dp 和 trans_record
    dp = np.full((n_stocks + 1, K + 2), -np.inf)
    dp_prev = np.full((n_stocks + 1, K + 2), -np.inf)
    trans_record = {}

    # 第 0 天初始化
    dp_prev[0][1] = cash_init  # 持有現金，累計持有現金天數為 1
    for s in range(1, n_stocks + 1):
        dp_prev[s][0] = cash_init / priceMat[0][s - 1] * (1 - transFeeRate)
        trans_record[(0, s, 0)] = (0, 0, 1)  # 由現金買入

    # 動態規劃主循環
    for i in range(1, days):
        dp_new = np.full((n_stocks + 1, K + 2), -np.inf)
        for h in range(K + 1):
            # 狀態為持有現金
            if dp_prev[0][h] > -np.inf:
                # 繼續持有現金
                new_h = min(h + 1, K + 1)
                if dp_new[0][new_h] < dp_prev[0][h]:
                    dp_new[0][new_h] = dp_prev[0][h]
                    trans_record[(i, 0, new_h)] = (i - 1, 0, h)

                # 用現金買入股票
                for s in range(1, n_stocks + 1):
                    units = dp_prev[0][h] / priceMat[i][s - 1] * (1 - transFeeRate)
                    if dp_new[s][h] < units:
                        dp_new[s][h] = units
                        trans_record[(i, s, h)] = (i - 1, 0, h)

            # 狀態為持有股票
            for k in range(1, n_stocks + 1):
                if dp_prev[k][h] > -np.inf:
                    # 繼續持有股票
                    if dp_new[k][h] < dp_prev[k][h]:
                        dp_new[k][h] = dp_prev[k][h]
                        trans_record[(i, k, h)] = (i - 1, k, h)

                    # 賣出股票，獲得現金
                    cash = dp_prev[k][h] * priceMat[i][k - 1] * (1 - transFeeRate)
                    new_h = min(h + 1, K + 1)
                    if dp_new[0][new_h] < cash:
                        dp_new[0][new_h] = cash
                        trans_record[(i, 0, new_h)] = (i - 1, k, h)

                    # 賣出股票並買入其他股票
                    for s in range(1, n_stocks + 1):
                        if s != k:
                            cash = dp_prev[k][h] * priceMat[i][k - 1] * (1 - transFeeRate)
                            units = cash / priceMat[i][s - 1] * (1 - transFeeRate)
                            if dp_new[s][h] < units:
                                dp_new[s][h] = units
                                trans_record[(i, s, h)] = (i - 1, k, h)

        dp_prev = dp_new  # 更新 dp

    # 終止條件
    max_wealth = -np.inf
    final_state = None
    for h in range(K, K + 2):
        for k in range(n_stocks + 1):
            if dp_prev[k][h] > -np.inf:
                if k == 0:
                    wealth = dp_prev[k][h]
                else:
                    wealth = dp_prev[k][h] * priceMat[days - 1][k - 1] * (1 - transFeeRate)
                if wealth > max_wealth:
                    max_wealth = wealth
                    final_state = (days - 1, k, h)

    if final_state is None:
        # 無法滿足持有現金天數至少為 K 的約束
        return []

    # 回溯構建 actionMat
    actionMat = []
    i, k, h = final_state
    while i >= 0:
        prev_state = trans_record.get((i, k, h))
        if prev_state is None:
            break
        prev_i, prev_k, prev_h = prev_state
        if k == 0:
            # 當前持有現金
            if prev_k != 0:
                # 賣出股票 prev_k 獲得現金
                amount = dp_prev[prev_k][prev_h] * priceMat[i][prev_k - 1]
                actionMat.append([i, prev_k - 1, -1, amount])
            h = prev_h
        else:
            if prev_k == 0:
                # 從現金買入股票 k
                amount = dp_prev[k][h] * priceMat[i][k - 1] / (1 - transFeeRate)
                actionMat.append([i, -1, k - 1, amount])
            elif prev_k != k:
                # 從股票 prev_k 換到股票 k
                amount = dp_prev[prev_k][prev_h] * priceMat[i][prev_k - 1]
                actionMat.append([i, prev_k - 1, k - 1, amount])
            h = prev_h
        k = prev_k
        i = prev_i

    actionMat.reverse()
    return actionMat

# An approach that allow consecutive K days to hold all cash without any stocks
def myAction03(priceMat, transFeeRate, K):
    days, n_stocks = priceMat.shape
    cash_init = 1000.0

    # 狀態變數：dp[k][c][f]，持有狀態為 k，連續持有現金天數為 c，是否已達到目標為 f 的最大資產值
    dp_prev = np.full((n_stocks + 1, K + 1, 2), -np.inf)
    dp = np.full((n_stocks + 1, K + 1, 2), -np.inf)
    trans_record = {}

    # 初始化第 0 天
    # 持有現金
    c = 1
    f = 1 if c >= K else 0
    dp_prev[0][c][f] = cash_init
    trans_record[(0, 0, c, f)] = None  # 初始狀態無前驅

    # 用現金買入股票
    for s in range(1, n_stocks + 1):
        units = cash_init / priceMat[0][s - 1] * (1 - transFeeRate)
        dp_prev[s][0][0] = units
        trans_record[(0, s, 0, 0)] = None  # 初始狀態無前驅

    # 動態規劃主循環
    for i in range(1, days):
        dp.fill(-np.inf)
        for k in range(n_stocks + 1):
            for c in range(K + 1):
                for f in range(2):
                    if dp_prev[k][c][f] > -np.inf:
                        current_value = dp_prev[k][c][f]
                        # 狀態轉移
                        if k == 0:
                            # 當前持有現金
                            # 繼續持有現金
                            new_c = min(c + 1, K)
                            new_f = 1 if f == 1 or new_c >= K else 0
                            if dp[0][new_c][new_f] < current_value:
                                dp[0][new_c][new_f] = current_value
                                trans_record[(i, 0, new_c, new_f)] = (i - 1, 0, c, f)

                            # 用現金買入股票
                            if f == 1 or c < K:
                                for s in range(1, n_stocks + 1):
                                    units = current_value / priceMat[i][s - 1] * (1 - transFeeRate)
                                    if dp[s][0][f] < units:
                                        dp[s][0][f] = units
                                        trans_record[(i, s, 0, f)] = (i - 1, 0, c, f)
                        else:
                            # 當前持有股票
                            # 繼續持有股票
                            if dp[k][0][f] < current_value:
                                dp[k][0][f] = current_value
                                trans_record[(i, k, 0, f)] = (i - 1, k, 0, f)

                            # 賣出股票，獲得現金
                            cash = current_value * priceMat[i][k - 1] * (1 - transFeeRate)
                            new_c = 1
                            new_f = 1 if f == 1 or new_c >= K else 0
                            if dp[0][new_c][new_f] < cash:
                                dp[0][new_c][new_f] = cash
                                trans_record[(i, 0, new_c, new_f)] = (i - 1, k, 0, f)

                            # 賣出股票並買入其他股票
                            for s in range(1, n_stocks + 1):
                                if s != k:
                                    cash = current_value * priceMat[i][k - 1] * (1 - transFeeRate)
                                    units = cash / priceMat[i][s - 1] * (1 - transFeeRate)
                                    if dp[s][0][f] < units:
                                        dp[s][0][f] = units
                                        trans_record[(i, s, 0, f)] = (i - 1, k, 0, f)
        dp_prev, dp = dp, dp_prev  # 交換 dp

    # 終止條件
    max_wealth = -np.inf
    final_state = None
    for k in range(n_stocks + 1):
        for c in range(K + 1):
            f = 1  # 只考慮已經達到目標的狀態
            if dp_prev[k][c][f] > -np.inf:
                if k == 0:
                    wealth = dp_prev[k][c][f]
                else:
                    wealth = dp_prev[k][c][f] * priceMat[days - 1][k - 1] * (1 - transFeeRate)
                if wealth > max_wealth:
                    max_wealth = wealth
                    final_state = (days - 1, k, c, f)

    if final_state is None:
        # 無法滿足連續持有現金 K 天的約束
        return []

    # 回溯構建 actionMat
    actionMat = []
    state = final_state
    while state is not None:
        i, k, c, f = state
        prev_state = trans_record[state]
        if prev_state is not None:
            prev_i, prev_k, prev_c, prev_f = prev_state
            if k == 0:
                # 當前持有現金
                if prev_k == 0:
                    # 從現金持有到現金持有
                    pass
                else:
                    # 賣出股票
                    amount = dp_prev[prev_k][prev_c][prev_f] * priceMat[i][prev_k - 1]
                    actionMat.append([i, prev_k - 1, -1, amount])
            else:
                if prev_k == 0:
                    # 從現金買入股票
                    amount = dp_prev[prev_k][prev_c][prev_f] / (1 - transFeeRate)
                    actionMat.append([i, -1, k - 1, amount])
                elif prev_k == k:
                    # 繼續持有股票
                    pass
                else:
                    # 從股票 prev_k 換到股票 k
                    amount = dp_prev[prev_k][prev_c][prev_f] * priceMat[i][prev_k - 1]
                    actionMat.append([i, prev_k - 1, k - 1, amount])
        state = prev_state

    actionMat.reverse()
    return actionMat
