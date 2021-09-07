import React, { ReactElement, useState } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';
import { currentCountry } from '../../components/byCountry/selectedCountrySlice';
import { useAppSelector } from '../../store/hooks';
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';

const Who: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();
    // const count = useAppSelector(currentCountry);
    const [selectedCountry, setSelectedCountry] = useState<Covid19DataByCountry>();
    return (
        <Layout>
            <bt.Container>
                <bt.Row>
                    <bt.Col> Under development </bt.Col>
                </bt.Row>
            </bt.Container>
        </Layout>
    )
};

export default Who;