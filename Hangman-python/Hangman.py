import random

class WordBank:
    def __init__(self):
        self.__words = [
            "algorytmy", "komputer", "uczelnia", "kura", 
            "maksymalnie", "piosenka", "wisielec", "zaliczenie"
            ]
    def get_random_word(self):
        return random.choice(self.__words).lower()

if __name__ == "__main__":
    game = Game()
    game.start()
