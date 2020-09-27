import os
import random
clear = lambda: os.system('cls')
def field():
   print(f'***********\n {pole[0]} | {pole[1]} | {pole[2]} \n---+---+---\n {pole[3]} | {pole[4]} | {pole[5]} \n---+---+---\n {pole[6]} | {pole[7]} | {pole[8]} \n***********')
pole = [1,2,3,4,5,6,7,8,9]
win = 'false'

def checkIfWin():
    if pole[0] == pole[1] == pole[2] or pole[3]==pole[4]==pole[5] or pole[6]==pole[7]==pole[8] or pole[0] == pole[3] == pole[6] or pole[1]==pole[4]==pole[7] or pole[3]==pole[5]==pole[8] or pole[0]==pole[4]==pole[8] or pole[2]==pole[4]==pole[6]:
        global win 
        win = 'true'

usedFields = []
def xTurn():
    player1 = int(input('X player turn, please choose a field: '))
    while int(player1) in usedFields:
        player1 = int(input('You can\'t use used fields, please X in free space: '))
    if player1 > 0 and player1<10:
        clear()
        usedFields.append(int(player1))
        pole[player1-1] = 'X'
        field()

def oTurn():
    player2 = int(input('O player turn, please choose a field: '))
    while int(player2) in usedFields:
        player2 = int(input('You can\'t use used fields, please O in free space: '))
    if player2 > 0 and player2<10:
        clear()
        usedFields.append(int(player2))
        pole[player2-1] = 'O'
        field()

def pcTurn():
    pcValue = random.randint(1,9)
    while int(pcValue) in usedFields:
        pcValue = random.randint(1,9)
    if pcValue > 0 and pcValue<10:
        clear()
        usedFields.append(int(pcValue))
        pole[pcValue-1] = 'O'
        field()

def pvp():
    clear()
    field()
    turn, turnNumber = 1, 0
    while win != 'true' and turnNumber < 9:
        if turn == 1:
            xTurn()
            turn = 0
        elif turn == 0:
             oTurn()
             turn = 1
        checkIfWin()
        turnNumber += 1
  
    if win == 'true':
        print('Noice! Someone Won!')
    else:
        print('Bummer!')

def pvc():
    clear()
    field()
    turn, turnNumber = 1, 0
    while win != 'true' and turnNumber < 9:
        if turn == 1:
            xTurn()
            turn = 0
        elif turn == 0:
             pcTurn()
             turn = 1
        checkIfWin()
        turnNumber += 1
  
    if win == 'true':
        print('\no---.___\no---\'---\n\nYou Won!\nWhat you gonna do now, huh? Maybe jerk off? Piss your pants? Maybe shit and cum?')   
    else:
        print('Bummer!')

#start of program
mode = int(input('Welcome to my humble game you cunt. Please choose mode you prefer:\n1. Play with myself (it might be pvp, but I know that you\'re lonely af ;])\n2. Play with computer (You\'ll see titties if you manage to win, tho.)\n>'))
while mode not in [1,2]:
    mode = int(input('Type "1" or "2" you stupid useless cunt... '))
if mode == 1:
    pvp()
elif mode == 2:
    pvc()

input()