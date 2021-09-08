import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import ByRegion from '../../components/byRegion';
import TopCountry from '../../components/byCountry/topCountries';
import InformationAlert from '../../components/informationAlert';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';
import { useGetCurrentCountryQuery } from '../../services/getCurrentCountry';
import { CurrentCountry } from '../../types/currentCountry';
import ByCurrentCountry from '../../components/byCurrentCountry';

const Home: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();
    const getGurrentCountry = useGetCurrentCountryQuery();

    const defaultCountry: CurrentCountry = {
        country: "VN",
        countryCode: "VN",
        query: "127.0.0.1",
    };
    return (
        <Layout>
            <InformationAlert />
            {getGurrentCountry.isSuccess && getGurrentCountry.data && (
                <ByCurrentCountry cc={getGurrentCountry.data} />
            )
            }
            {!getGurrentCountry.isSuccess && !getGurrentCountry.data && (
                <ByCurrentCountry cc={defaultCountry} />
            )
            }
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