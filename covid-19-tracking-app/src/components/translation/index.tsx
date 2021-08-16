import React, { useContext } from 'react';
import { dictionaryList } from '../../locales';
import { useAppContext } from '../../contexts/appContext';

type props = {
    tid: string;
}
export const Translation: React.FC<props> = (props) => {
    const { locale } = useAppContext();
    const { tid } = props;
    return dictionaryList[locale][tid] || tid
};

export const PTranslation: React.FC<props> = ({ tid }) => {
    const { locale } = useAppContext();
    return <p>{dictionaryList[locale][tid] || tid}</p>
};
