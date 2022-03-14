#!/usr/bin/python3
# -*- coding: utf-8 -*-

import unittest
import dictionary_parser

class DictionaryParserTests(unittest.TestCase):

    def test_parse_easy_string(self):
        input_text = "a=1;b=2;c=3"

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "1", "b" : "2", "c" : "3"}, result)

    def test_parse_string_with_duplicate_key(self):
        input_text = "a=1;a=2"

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "2"}, result)

    def test_parse_string_with_spaces(self):
        input_text = " a = 1 ; b = 2 "

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "1", "b" : "2"}, result)

    def test_parse_string_with_extra_semi_colon(self):
        input_text = "a=1;;b=2"

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "1", "b" : "2"}, result)

    def test_insert_empty_value_for_missing_input_value(self):
        input_text = "a="

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : ""}, result)

    def test_create_empty_dictionary_for_empty_input_string(self):
        input_text = ""

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual(dict(), result)

    def test_keep_additional_equals_sign_as_part_of_value(self):
        input_text = "a==1"

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "=1"}, result)

    def test_raise_exception_for_missing_input_key(self):
        input_text = "=1"

        self.assertRaises(KeyError, lambda: dictionary_parser.parse(input_text))

    def test_raise_exception_for_missing_equals_sign(self):
        input_text = "a"

        self.assertRaises(KeyError, lambda: dictionary_parser.parse(input_text))

    def test_parse_input_string_with_all_problems_combined(self):
        input_text = " a = 1 ; ; c =  ; ; b = = 2 "

        result = dictionary_parser.parse(input_text)

        self.assertDictEqual({"a" : "1", "b" : "= 2", "c" : ""}, result)


if __name__ == '__main__':
    unittest.main()