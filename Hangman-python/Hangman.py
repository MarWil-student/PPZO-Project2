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

class Game:
    def __init__(self):
        self.__word_bank = WordBank()
        self.__secret_word = self.__word_bank.get_random_word()
        self.__player = Player()
        self.__max_mistakes = 6
    def start(self):
        print("====  Gra Wisielec  ====")
        print(f"Zasady: Zgadnij slowo, maksymalna ilosc pomylek to {self.__max_mistakes}")
        while self.__player.mistakes < self.__max_mistakes:
            self.__display_board()
            guess = self.__get_valid_input()
            if self.__player.already_guessed(guess):
                print(f"\n Litera '{guess}' byla juz wybrana")
                continue
            self.__player.register_letter(guess)
            if guess in self.__secret_word:
                print("\n Poprawna litera!")
            else:
                self.__player.ad_mistake()
                print(f"\n Pudlo! Pozostalo bledow: {self.__max_mistakes - self.__player.mistakes}")
            if self.__win():
                self.__display_board()
                print("\n====  Gratulacje wygrana!  ====")
                return
         print(f"\nPrzegrana! Wisielec gotowy. Slowo to: {self.__secret_word}")
    def __display_board(self):
        print("\nSlowo:")
        display = [c if self.__player.already_guessed(c) else "_" for c in self.__secret_word]
        print(" ".join(display))
    def __get_valid_input(self):
        while True:
            user_input = input("\nPodaj jedna litere: ").strip().lower()
            if not user_input or len(user_input != 1:
                print("BLAD: Musisz wpisac dokladnie jedna litere")
                continue
            if not user_input.isalpha():
                print("BLAD: Znaki inne niz litery nie sa akceptowane")
                continue
            return user_input
    def __win(self):
        return all(c in self.__player.guessed_letters for c in self.__secret_word)

if __name__ == "__main__":
    game = Game()
    game.start()
