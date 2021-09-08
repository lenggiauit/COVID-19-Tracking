import React, { ReactElement, useState } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';
import { currentCountry } from '../../components/byCountry/selectedCountrySlice';
import { useAppSelector } from '../../store/hooks';
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';
import { useLocation } from 'react-router-dom';
import PageNotFound from '../../components/pageNotFound';
import CountryDetail from '../../components/byCountry/detail';

const Country: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();
    const { state } = useLocation<Covid19DataByCountry>();
    if (state) {
        return (
            <Layout>
                <bt.Container>
                    <bt.Row>
                        <CountryDetail selectedItemData={state} />
                    </bt.Row>
                </bt.Container>
            </Layout>
        )
    } else {
        return (
            <Layout>
                <PageNotFound />
            </Layout>
        )
    }
};

export default Country;