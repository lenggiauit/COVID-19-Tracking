import React, { ReactElement } from 'react';
import * as bt from 'react-bootstrap';
import Layout from '../../components/layout';
import { useAppContext } from '../../contexts/appContext';
import { RouteComponentProps } from "react-router-dom";
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import { useLocation } from 'react-router-dom';
import PageNotFound from '../../components/pageNotFound';
import RegionDetail from '../../components/byRegion/detail';
interface RouteParams {
    regiondata: Covid19DataByRegion
}


const Region: React.FC<RouteParams> = (props): ReactElement => {
    const { locale, setLocale, appSetting } = useAppContext();
    const { state } = useLocation<Covid19DataByRegion>();
    if (state) {
        return (
            <Layout>
                <bt.Container>
                    <bt.Row>
                        <RegionDetail selectedItemData={state} />
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

export default Region;