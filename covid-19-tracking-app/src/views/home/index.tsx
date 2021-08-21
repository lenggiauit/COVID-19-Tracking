import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import InformationAlert from '../../components/informationAlert';
import Layout from '../../components/layout';
import Totals from '../../components/totals';
import { useAppContext } from '../../contexts/appContext';

const Home: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();


    return (
        <Layout>
            <InformationAlert />
            <Totals />
        </Layout>
    )
};

export default Home;