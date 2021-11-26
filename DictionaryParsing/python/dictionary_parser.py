#!/usr/bin/python3
# -*- coding: utf-8 -*-

def _parse_key_value_pair(pair : str) -> tuple:
    if not "=" in pair:
        raise KeyError("Equals sign is missing from input string!")
        
    key_value_pair = pair.split("=", 1)
    key = key_value_pair[0].strip()
    value = key_value_pair[1].strip()
    
    if not key:
        raise KeyError("Key is missing from input string!")
        
    return (key, value)
    

def parse(text: str) -> dict:
    
    dictionary = dict()
    
    pairs = [pair.strip() for pair in text.split(";")]
    pairs_with_content = [pair for pair in pairs if pair]
    key_value_pairs = [_parse_key_value_pair(pair) for pair in pairs_with_content]
    
    for key_value_pair in key_value_pairs:
        key, value = key_value_pair
        dictionary[key] = value
    
    return dictionary