import numpy as np
from matplotlib import pyplot as plt
import re

replacements = {
    '^': '**',
}

allowed_words = [
    'x',
    '+',
    '-',
    '*',
    '/',
    '^',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9',
    '0',
]

def string2func(string):
    for word in string:
        if word not in allowed_words:
            raise ValueError(
                '"{}" is forbidden to use in math expression'.format(word)
            )

    for old, new in replacements.items():
        string = string.replace(old, new)

    def func(x):
        return eval(string)

    return func


if __name__ == '__main__':
    
    y=[]
    with open("func.txt",'r') as f:
        f.seek(0)
        func = string2func(f.read())
        
    
    with open("limits.txt",'r') as f:
        f.seek(0)
        for line in f.readlines():
            y.append(line)
    
    
    a = int(y[0])
    b = int(y[1])
    x = np.linspace(a, b, 250)

    plt.plot(x, func(x))
    plt.xlim(a, b)
    plt.savefig("plt.png")