import numpy as np
from scipy.optimize import fsolve

def npv(cashFlowVec, rate, cashFlowPeriod, compoundPeriod):
    sum = 0
    n = len(cashFlowVec)
    period = cashFlowPeriod // compoundPeriod
    paymentperiod = 12 // compoundPeriod
    for i, cf in enumerate(cashFlowVec):
        sum += cf * (1 + rate / paymentperiod) ** ((n - i) * period)
    return sum

def irrFind(cashFlowVec, cashFlowPeriod, compoundPeriod):
    initial_guess = 0
    irr = fsolve(lambda r: npv(cashFlowVec, r, cashFlowPeriod, compoundPeriod), initial_guess)[0]
    return irr