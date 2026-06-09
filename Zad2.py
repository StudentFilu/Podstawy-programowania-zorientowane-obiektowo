import random

class Player:
    def __init__(self, name):
        self.name = name

class WordBank:
    def __init__(self):
        self.words = ["prokrastynacja", "python", "Hiszpania", "wulkanizacja", "elektrokardiogram"]

    def get_random_word(self) -> str:
        return random.choice(self.words)

class Game:
    def __init__(self, player: Player, word_bank: WordBank, max_errors: int = 6):
        self.player = player
        self.word_bank = word_bank
        self.max_errors = max_errors
        self.secret_word = word_bank.get_random_word().lower()
        self.guessed_letters = set()
        self.errors = 0
    
    def get_display_word(self) -> str:

        return " ".join([char if char in self.guessed_letters else "_" for char in self.secret_word])
    def guess_letter(self, letter: str) -> bool:
        letter = letter.lower()

        if letter in self.guessed_letters:
            print(f"Już zgadłeś literę '{letter}'.")
            return False
        
        if letter in self.secret_word:
            self.guessed_letters.add(letter)
            print(f"Dobra robota! Litera '{letter}' jest w słowie.")
            return True
        else:
            self.errors += 1
            print(f"Niestety, litera '{letter}' nie jest w słowie. Błąd {self.errors}/{self.max_errors}.")
            return False

    def is_won(self) -> bool:
        return all(char in self.guessed_letters for char in self.secret_word)
    
    def is_lost(self) -> bool:
        return self.errors >= self.max_errors
    
    def start_loop(self):
        print(f"Witaj, {self.player.name}! Zacznijmy grę w wisielca!")

        while not self.is_won() and not self.is_lost():
            print(f"Słowo: {self.get_display_word()}")
            letter = input("Zgadnij literę: ").strip()
        
            if len(letter) != 1 or not letter.isalpha():
                print("Proszę, wpisz pojedynczą literę.")
                continue

            self.guess_letter(letter)

        if self.is_won():
            print(f"Gratulacje, {self.player.name}! Wygrałeś! Słowo to '{self.secret_word.upper()}'.")
        else:
            print(f"Niestety, przegrałeś. Słowo to '{self.secret_word.upper()}'.")

if __name__ == "__main__":
    player_name = input("Podaj swoje imię: ")
    player = Player(player_name)
    word_bank = WordBank()
    game = Game(player, word_bank)
    game.start_loop()