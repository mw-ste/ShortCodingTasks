#!/usr/bin/python3
# -*- coding: utf-8 -*-

import unittest
import dictionary_parser

class Dictionary_Parser_Tests(unittest.TestCase):
    
    def test_parse_easy_string(self):
        inputText = "a=1;b=2;c=3"
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "1", "b" : "2", "c" : "3"}, result)
        
    def test_parse_string_with_duplicate_key(self):
        inputText = "a=1;a=2"
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "2"}, result)
        
    def test_parse_string_with_spaces(self):
        inputText = " a = 1 ; b = 2 "
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "1", "b" : "2"}, result)
        
    def test_parse_string_with_extra_semi_colon(self):
        inputText = "a=1;;b=2"
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "1", "b" : "2"}, result)
        
    def test_insert_empty_value_for_missing_input_value(self):
        inputText = "a="
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : ""}, result)
        
    def test_create_empty_dictionary_for_empty_input_string(self):
        inputText = ""
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual(dict(), result)
        
    def test_keep_additional_equals_sign_as_part_of_value(self):
        inputText = "a==1"
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "=1"}, result)
        
    def test_raise_exception_for_missing_input_key(self):
        inputText = "=1"
        
        self.assertRaises(KeyError, lambda: dictionary_parser.parse(inputText))
        
    def test_raise_exception_for_missing_equals_sign(self):
        inputText = "a"
        
        self.assertRaises(KeyError, lambda: dictionary_parser.parse(inputText))
        
    def test_parse_input_string_with_all_problems_combined(self):
        inputText = " a = 1 ; ; c =  ; ; b = = 2 "
        
        result = dictionary_parser.parse(inputText)
        
        self.assertDictEqual({"a" : "1", "b" : "= 2", "c" : ""}, result)


if __name__ == '__main__':
    unittest.main()