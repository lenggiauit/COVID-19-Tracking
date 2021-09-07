import { Dictionary } from '../types/type';
import en from './en.json';
import vn from './vn.json';
import countries from './countries.json';
export const dictionaryList: Dictionary<any> = { "en": en, "vn": vn };
export const localeOptions: Dictionary<any> = {
    en: 'English',
    vn: 'Tiếng việt',
};

export const KeyValues: Dictionary<any> = { "country": countries };


