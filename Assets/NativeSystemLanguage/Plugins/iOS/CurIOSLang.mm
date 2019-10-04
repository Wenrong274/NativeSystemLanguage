char* cStringCopy(const char* string)
{
  if(string == NULL){
    return NULL;
  }
  char* newString = (char*)malloc(strlen(string) + 1);
  strcpy(newString, string);
  return newString;
}

extern "C"
{
  const char* CurIOSLang ()
  {
    NSArray *languages = [NSLocale preferredLanguages];
    NSString *CurrentLanguage = [languages objectAtIndex:0];
    return cStringCopy([CurrentLanguage UTF8String]);
  }
}