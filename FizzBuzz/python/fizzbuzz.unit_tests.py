#!/usr/bin/python3
# -*- coding: utf-8 -*-

import io
import sys
import unittest
import fizzbuzz


class FizzBuzzTests(unittest.TestCase):

    _string_io = None
    _default_stdout = None

    def setUp(self):
        self._string_io = io.StringIO()
        self._default_stdout = sys.stdout
        sys.stdout = self._string_io

    def tearDown(self):
        sys.stdout = self._default_stdout

    def assert_printed(self, expected_text: str):
        self.assertEqual(expected_text, self._string_io.getvalue())

    def test_print_fizz_for_values_divisible_by_3(self):
        # arrange
        input_values = [3, 6, 9]
        expected_output = "Fizz\n" * 3

        # act
        fizzbuzz.run(input_values)

        # assert
        self.assert_printed(expected_output)

    def test_print_buzz_for_values_divisible_by_5(self):
        # arrange
        input_values = [5, 10, 25]
        expected_output = "Buzz\n" * 3

        # act
        fizzbuzz.run(input_values)

        # assert
        self.assert_printed(expected_output)

    def test_print_fizz_buzz_for_values_divisible_by_3_and_5(self):
        # arrange
        input_values = [0, 15, 30]
        expected_output = "FizzBuzz\n" * 3

        # act
        fizzbuzz.run(input_values)

        # assert
        self.assert_printed(expected_output)

    def test_print_number_for_values_not_divisible_by_3_or_5(self):
        # arrange
        input_values = [1, 2, 4]
        expected_output = "".join(["{}\n".format(num) for num in input_values])

        # act
        fizzbuzz.run(input_values)

        # assert
        self.assert_printed(expected_output)

    def test_print_correct_output_for_sequence(self):
        # arrange
        input_values = range(1, 17)
        expected_output = "\n".join(
            ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8",
             "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz", "16\n"])

        # act
        fizzbuzz.run(input_values)

        # assert
        self.assert_printed(expected_output)


if __name__ == '__main__':
    unittest.main()
