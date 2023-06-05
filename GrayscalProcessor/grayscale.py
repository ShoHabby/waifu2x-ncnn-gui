import sys
from typing import List, AnyStr
from PIL import Image, UnidentifiedImageError
from os.path import isdir, join
from glob import glob


def main(args: List[str]) -> None:

    if len(args) <= 1:
        print("This program must be ran via the command line, and a path to the raw image(s) must be provided.")
        input("Press enter to exit...")
        sys.exit()

    path: str = args[1]
    if isdir(path):
        files: List[AnyStr] = glob(join(path, "*.png")) + glob(join(path, "*.jp*g")) + glob(join(path, "*.webp"))
        for file in files:
            to_grayscale(file)
    else:
        to_grayscale(path)


def to_grayscale(file: str) -> None:

    # noinspection PyBroadException
    try:
        Image.open(file).convert("L").save(file)
        print(f"Converted image {file} to grayscale")
    except FileNotFoundError:
        print(f"The file {file} could not be found")
    except UnidentifiedImageError:
        print(f"The image {file} could not be opened or identified, is pillow-avif-plugin installed?")
    except ValueError:
        print(f"The image {file} has an unknown or unsupported file extension")
    except OSError:
        print(f"The image {file} could not be saved to the disk")
    except Exception:
        print(f"An unknown exception has occurred while converting file {file}")


if __name__ == '__main__':
    main(sys.argv)
