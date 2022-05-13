#!/usr/bin/python3
# -*- coding: utf-8 -*-


def run(values: list) -> None:
    for value in values:

        fizz = value % 3 == 0
        buzz = value % 5 == 0

        if fizz:
            print("Fizz", end="")

        if buzz:
            print("Buzz", end="")

        if not fizz and not buzz:
            print(value, end="")

        print("")
