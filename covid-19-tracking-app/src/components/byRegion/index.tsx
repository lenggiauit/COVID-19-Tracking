import React, { useEffect, useState } from 'react';
import { trackPromise } from 'react-promise-tracker';
import { toast, ToastContainer } from 'react-toastify';
import { useAppContext } from '../../contexts/appContext';
import { ApiResponse } from '../../type';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import ConverterLocaleDateString from '../../utils/converter';

const ByRegion: React.FC = () => {

    const { appSetting } = useAppContext();

    useEffect(() => {
        retrieveTotals();
    }, []);

    const retrieveTotals = () => {

    };

    return (
        <>
            <ToastContainer />
            <bt.Container>
                <bt.Row>
                    <header className="pb-3 mt-4 border-bottom">
                        <h2 className="fs-3"> <Translation tid="who_reported_byregion_title" /></h2>
                    </header>

                </bt.Row>
            </bt.Container>
        </>
    )
}

export default ByRegion;