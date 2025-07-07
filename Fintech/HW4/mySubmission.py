#############################################################
# Problem 0: Find base point
def GetCurveParameters():
    # Certicom secp256-k1
    # Hints: https://en.bitcoin.it/wiki/Secp256k1
    _p = 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F
    _a = 0x0000000000000000000000000000000000000000000000000000000000000000
    _b = 0x0000000000000000000000000000000000000000000000000000000000000007
    _Gx = 0x79BE667EF9DCBBAC55A06295CE870B07029BFCDB2DCE28D959F2815B16F81798
    _Gy = 0x483ADA7726A3C4655DA4FBFC0E1108A8FD17B448A68554199C47D08FFB10D4B8
    _Gz = 0x0000000000000000000000000000000000000000000000000000000000000001
    _n = 0xFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141
    _h = 0x01
    return _p, _a, _b, _Gx, _Gy, _Gz, _n, _h


#############################################################
# Problem 1: Evaluate 4G
def compute4G(G, callback_get_INFINITY):
    """Compute 4G"""
    result = 4 * G
    return result


#############################################################
# Problem 2: Evaluate 5G
def compute5G(G, callback_get_INFINITY):
    """Compute 5G"""
    result = 5 * G
    return result


#############################################################
# Problem 3: Evaluate dG
# Problem 4: Double-and-Add algorithm
def double_and_add(n, point, callback_get_INFINITY):
    """Calculate n * point using the Double-and-Add algorithm."""
    result = callback_get_INFINITY()
    num_doubles = 0
    num_additions = 0

    # 將 n 轉換為二進位制字串，去掉 '0b' 前綴
    n_bin = bin(n)[2:]

    for bit in n_bin:
        # 如果 result 不是無限遠點，則對其進行加倍
        if result != callback_get_INFINITY():
            result = result.double()
            num_doubles += 1
        # 如果當前位是 '1'，則將點相加
        if bit == '1':
            if result == callback_get_INFINITY():
                result = point
            else:
                result = result + point
                num_additions += 1
    return result, num_doubles, num_additions


#############################################################
# Problem 5: Optimized Double-and-Add algorithm
def evaluate_cost(n, bits):
    """
    計算使用 2^bits ± remainder 來表示 n 的運算成本。
    bits: 2 的次方數量
    remainder: 剩餘的值，可以為正或負
    """    
    power_of_two = 1 << bits  
    prior_power_of_two = 1 << (bits - 1)  

    remainder_minus_one = n - prior_power_of_two
    remainder_minus_n = power_of_two - n  

    remainder = remainder_minus_one if remainder_minus_one < remainder_minus_n else remainder_minus_n 

    optimized_double = bits - 1 if remainder == remainder_minus_one else bits

    return optimized_double, remainder

def optimized_double_and_add(n, point, callback_get_INFINITY):
    """
    Optimized version of the double-and-add algorithm using precomputed optimizations for evaluating scalar multiplication.

    Parameters:
    n (int): The scalar to multiply.
    point (tuple): The base point on the elliptic curve.
    callback_get_INFINITY (function): Callback to get the point at infinity.

    Returns:
    tuple: result (tuple), num_doubles (int), num_additions (int)
    """
    # Start with the point at infinity as the initial result.
    result = callback_get_INFINITY()

    bits = n.bit_length()
    # 計算傳統方法的成本
    num_doubles = bits - 1  
    num_additions = bin(n).count('1') - 1     

    optimized_add = 0

    # print(bits)
    optimized_double, remainder = evaluate_cost(n, bits)
    # print(optimized_double)
    optimized_add += 1
    r_bits = remainder.bit_length()

    while remainder != 1 << (r_bits - 1):
        # print(r_bits) 
        double, remainder = evaluate_cost(remainder, r_bits)
        r_bits = remainder.bit_length()
        optimized_add += 1

    # print(optimized_double)
    # print(optimized_add)

    # 如果最佳分解方式的成本高於或等於傳統方法，則使用傳統方法
    if optimized_double + optimized_add <= num_doubles + num_additions:
        num_doubles = optimized_double
        num_additions = optimized_add

    if n != 0:
        result = n * point

    return result, num_doubles, num_additions



#############################################################
# Problem 6: Sign a Bitcoin transaction with a random k and private key d
def sign_transaction(private_key, hashID, callback_getG, callback_get_n, callback_randint):
    """Sign a bitcoin transaction using the private key."""
    G = callback_getG()
    n = callback_get_n()
    e = int(hashID, 16)  # 將 hashID 轉換為整數

    while True:
        k = callback_randint(1, n - 1)
        R = k * G
        r = R.x() % n
        if r == 0:
            continue
        k_inv = pow(k, -1, n)
        s = (k_inv * (e + private_key * r)) % n
        if s == 0:
            continue
        return (r, s)


##############################################################
# Problem 7: Verify the digital signature with the public key Q
def verify_signature(public_key, hashID, signature, callback_getG, callback_get_n, callback_get_INFINITY):
    """Verify the digital signature."""
    G = callback_getG()
    n = callback_get_n()
    infinity_point = callback_get_INFINITY()
    r, s = signature

    if not (1 <= r < n and 1 <= s < n):
        return False

    e = int(hashID, 16)
    w = pow(s, -1, n)
    u1 = (e * w) % n
    u2 = (r * w) % n

    # 計算點 X = u1 * G + u2 * Q
    X = u1 * G + u2 * public_key
    if X == infinity_point:
        return False

    v = X.x() % n
    return v == r
