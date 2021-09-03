import React, { useState, useCallback } from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { useGetListCaseByRegionQuery } from '../../services/getListCaseByRegion';
import LocalSpinner from "../localSpinner";
import { GetRandomBgColor } from '../../utils/functions';
import RegionItem from './item';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import RegionDetail from './detail';
import DetailLoading from './detailLoading';
import { uuid } from 'uuidv4';

const ByRegion: React.FC = () => {

    const { data, error, isFetching, isLoading } = useGetListCaseByRegionQuery();

    const [selectedItem, setSelectedItem] = useState<Covid19DataByRegion>();

    const selectedItemHandler = useCallback((item: Covid19DataByRegion) => {
        setSelectedItem(item);
    }, [selectedItem])


    return (
        <>
            <bt.Container>
                <bt.Row>
                    <bt.Col md={4}>
                        <h5>
                            <Translation tid="Situation_by_WHO_Region" />
                        </h5>
                    </bt.Col>
                    <bt.Col md={8}>
                    </bt.Col>

                </bt.Row>
                <bt.Row>
                    <bt.Col md={4}>
                        {(isFetching || isLoading) &&
                            <>{
                                Array.from(Array(7).keys()).map((i) => (
                                    <RegionItem key={uuid()} max={1} selectedItem={() => { }} />
                                ))
                            }
                            </>
                        }
                        {error && <div>{JSON.stringify(error)}</div>}
                        {!error && !isFetching && data?.success &&
                            <> {
                                data?.resource.map((item) => (
                                    <>
                                        <RegionItem key={uuid()} selectedItem={selectedItemHandler} data={item} max={Math.max.apply(Math, data?.resource.map(function (o) { return o.confirmed; }))} />
                                    </>
                                ))
                            }
                            </>
                        }
                    </bt.Col>
                    <bt.Col md={8} className="mt-2">
                        {(isFetching || isLoading) && <DetailLoading key={uuid()} lineCount={17} />}
                        {!selectedItem && data?.success && data?.resource[0] && (<>
                            <RegionDetail key={uuid()} selectedItemData={data?.resource[0]} />
                        </>)}
                        {selectedItem && (<>
                            <RegionDetail key={uuid()} selectedItemData={selectedItem} />
                        </>)}
                    </bt.Col>
                </bt.Row>

            </bt.Container>
        </>
    )
}

export default ByRegion;