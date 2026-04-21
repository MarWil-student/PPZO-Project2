import random

class WordBank:
    def __init__(self):
        self.__words = [
            "algorytmy", "komputer", "uczelnia", "kura", 
            "maksymalnie", "piosenka", "wisielec", "zaliczenie"
            ]
    def get_random_word(self):
        return random.choice(self.__words).lower()

class Player:
    def __init__(self):
        self.mistakes = 0
        self.guessed_letters = set()
    def add_mistakes(self):
        self.mistakes += 1
    def already_guessed(self, letter):
        return letter in self.guessed_letters
    def register_letter(self, letter):
        selg.guessed_letters.add(letter)

if __name__ == "__main__":
    game = Game()
    game.start()
