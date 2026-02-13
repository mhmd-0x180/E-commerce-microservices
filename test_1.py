#!usr/bin/env python
import argparse
import sys

def main():
    name = "Mohammed"
    age = 20
    ssn = 91012311

    parser = argparse.ArgumentParser(description="A simple user ID tool")

    parser.add_argument("-i", "--id",action="store_true", help="show user identify details" )
    args = parser.parse_args()
    
    if args.id:
        (print(f"the name is {name} and the age is {age} and ssn is {ssn}"))
    else:
        pass


if __name__ == "__main__":
    main()