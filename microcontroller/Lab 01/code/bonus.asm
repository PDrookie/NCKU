List p=18f4520
    #include<p18f4520.inc>
        CONFIG OSC = INTIO67
        CONFIG WDT = OFF
        org 0x00
	
	MOVLW b'11100000'
	MOVWF 0x001
	MOVWF 0x002
	COMF 0x001
	RRCF 0x002, 0
	MOVWF 0x012
	COMF 0x012
	ANDWF 0x001
	MOVF 0x012, w
	ANDWF 0x002
	MOVF 0x002, w
	IORWF 0x001	
	CLRF 0x002
	CLRF 0x012
	
	end
	


