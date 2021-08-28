import React, { useState, useEffect, ChangeEvent } from "react";
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { useAppContext } from '../../contexts/appContext';
import { ToastContainer, toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import ConverterLocaleDateString from "../../utils/converter";
import { useGetTotalsCaseQuery } from '../../services/totalsCaseAPI';
import LocalSpinner from "../localSpinner";



const InformationAlert: React.FC = () => {
    const { appSetting } = useAppContext();
    const { data, error, isFetching, isLoading } = useGetTotalsCaseQuery();


    return (
        <>
            <ToastContainer />
            <bt.Container>
                <bt.Row>
                    <div className="p-1 mt-4 text-center bg-info1 bg-gradient text-white1 rounded1-1 shadow-1sm">
                        <div className="container-fluid py-2">
                            <p className="col-md-12 fs-4">
                                {isFetching && <LocalSpinner />}
                                {error && <div>{JSON.stringify(error)}</div>}
                                {!error && !isFetching &&
                                    <>
                                        <Translation tid="who_reported_desciption1" />
                                        {ConverterLocaleDateString(data?.resource.updatedDate)}
                                        <Translation tid="who_reported_desciption2" />
                                        <span className="text-warning"><b>{data?.resource.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })}</b></span>
                                        <Translation tid="who_reported_desciption3" />
                                        <span className="text-danger"><b>{data?.resource.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</b></span>
                                        <Translation tid="who_reported_desciption4" />
                                    </>
                                }
                            </p>
                        </div>
                    </div>
                </bt.Row>
            </bt.Container>
        </>
    )
}

export default InformationAlert;