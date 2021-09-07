import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import ByRegion from '../../components/byRegion';
import TopCountry from '../../components/byCountry/topCountries';
import InformationAlert from '../../components/informationAlert';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';
import CurrentCountry from '../../components/byCurrentCountry';

const Home: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();


    return (
        <Layout>
            <InformationAlert />
            <CurrentCountry />
            <bt.Container>
                <bt.Row>
                    <bt.Col md={6}>
                        <ByRegion />
                    </bt.Col>
                    <bt.Col md={6}>
                        <TopCountry />
                    </bt.Col>
                </bt.Row>
            </bt.Container>
        </Layout>
    )
};

export default Home;