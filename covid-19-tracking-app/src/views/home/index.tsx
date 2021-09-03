import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import ByRegion from '../../components/byRegion';
import InformationAlert from '../../components/informationAlert';
import Layout from '../../components/layout';
import ByGlobal from '../../components/byGlobal';
import { useAppContext } from '../../contexts/appContext';

const Home: React.FC = (): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();


    return (
        <Layout>
            <InformationAlert />
            <ByRegion />
        </Layout>
    )
};

export default Home;